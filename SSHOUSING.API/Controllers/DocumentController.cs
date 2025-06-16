using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Application.DTOs;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocument _documentRepo;

        public DocumentController(IDocument documentRepo)
        {
            _documentRepo = documentRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DocumentDto>> GetAll()
        {
            var docs = _documentRepo.GetAll()
                .Select(d => new DocumentDto
                {
                    Id = d.Id,
                    FileName = d.FileName,
                    DocumentType = d.DocumentType,
                    UploadedAt = d.UploadedAt
                });

            return Ok(docs);
        }

        [HttpPost]
        public IActionResult Upload([FromBody] DocumentDto dto)
        {
            var doc = new Document
            {
                FileName = dto.FileName,
                DocumentType = dto.DocumentType,
                UploadedAt = DateTime.Now
            };

            _documentRepo.Add(doc);
            return Ok("Document uploaded successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _documentRepo.Delete(id);
            return Ok("Document deleted");
        }
    }
}
