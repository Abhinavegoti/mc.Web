using mc.EntityFrameworkCore;

namespace mc.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly mcDbContext _context;

        public InitialHostDbBuilder(mcDbContext context)
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
