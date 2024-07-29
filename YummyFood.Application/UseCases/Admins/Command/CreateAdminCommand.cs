using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Admins.Command
{
    public class CreateAdminCommand : IRequest<ResponseModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }
        public string PhoneNumber { get; set; }
    }
}
