﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<ResponseModel>
    {
        public string? Name { get; set; }
        public float Letitude { get; set; }
        public float Longitude { get; set; }
    }
}
