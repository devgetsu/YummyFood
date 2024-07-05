using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Products.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductCommandHandler(IWebHostEnvironment webHostEnvironment, IApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var file = request.Picture;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Directory created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }

            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Picture = "/ProductPhotos/" + fileName,
                CategoryId = request.CategoryId,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Product Created",
                StatusCode = 201,
            };
        }
    }
}
