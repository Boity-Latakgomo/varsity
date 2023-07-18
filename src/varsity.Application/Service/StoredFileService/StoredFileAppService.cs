using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.StoredFileService.Dto;
using varsity.Services.StoredFileService;

namespace varsity.Service.StoredFileService
{
    public class StoredFileAppService : ApplicationService, IStoredFileAppService
    {
        private readonly IRepository<Lecturer, Guid> _lecturerRepository;
        private readonly IRepository<StoredFile, Guid> _storedFileRepository;

        public StoredFileAppService(IRepository<Lecturer, Guid> lecturerRepository, IRepository<StoredFile, Guid> storedFileRepository)
        {
            _lecturerRepository = lecturerRepository;
            _storedFileRepository = storedFileRepository;
        }

        public async Task<StoredFileDto> UploadFile([FromForm] StoredFileDto form)
        {
            var userId = AbpSession.UserId;
            if (userId == null)
            {
                throw new ApplicationException("User invalid");
            }
            var person = await _lecturerRepository.FirstOrDefaultAsync(p => p.User.Id == userId);
            if (person == null)
            {
                throw new ApplicationException("Person invalid");
            }

            form.LecturerId = person.Id;

            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
            byte[] fileBytes = null;
            using (var ms = new MemoryStream())
            {
                await form.File.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            var lecturer = await _lecturerRepository.FirstOrDefaultAsync(form.LecturerId);

            var file = new StoredFile
            {
                Data = fileBytes,
                Name = form.File.FileName,
                FileType = form.File.ContentType,
            };

            file.Lecturer = person;

            file = await service.InsertAsync(file);
            var result = ObjectMapper.Map<StoredFileDto>(file);
            return result;
        }
        [HttpGet]
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
            var file = await service.GetAsync(fileId);

            if (file == null)
            {
                throw new ApplicationException("File Invalid!!!");
            }

            var stream = new MemoryStream(file.Data);

            stream.Position = 0;

            var contentType = file.FileType;
            var fileExtension = Path.GetExtension(file.Name);

            return new FileStreamResult(stream, contentType) { FileDownloadName = file.Name };
        }

        public async Task Delete(Guid id)
        {
            await _storedFileRepository.DeleteAsync(id);
        }

        public async Task<List<StoredFileDto>> GetFilesByApplicantId()
        {
            var files = await _storedFileRepository.GetAllIncluding(f => f.Lecturer).ToListAsync();
            var result = ObjectMapper.Map<List<StoredFileDto>>(files);
            return result;
        }

    }
}
