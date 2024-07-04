using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Categories.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateCategoryCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var file = request.Sticker;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Directory created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos", fileName);
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

            var category = new Category()
            {
                Name = request.Name,
                Sticker = "/CategoryPhotos/" + file.FileName,
            };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Created",
                StatusCode= 201,
            };
        }
    }
}
