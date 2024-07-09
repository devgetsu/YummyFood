using MediatR;
using Microsoft.AspNetCore.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Addresses.Commands
{
    public class FindTheClosestAddressCommand : IRequest<Object>
    {
        public float Letitude { get; set; }
        public float Longitude { get; set; }
    }
}
