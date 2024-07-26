using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.UseCases.Admins.Query
{
    public class GetAdminByIdQuery : IRequest<AdminApp>
    {
        public long Id { get; set; }
    }
}
