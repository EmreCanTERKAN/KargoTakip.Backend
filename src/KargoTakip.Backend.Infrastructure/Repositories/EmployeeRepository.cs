using KargoTakip.Backend.Domain.Employees;
using KargoTakip.Backend.Infrastructure.Context;
using GenericRepository;

namespace KargoTakip.Backend.Infrastructure.Repositories;
internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}