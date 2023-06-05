namespace varsity.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly varsityDbContext _context;

        public InitialHostDbBuilder(varsityDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
