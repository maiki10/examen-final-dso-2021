
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.Context;
using ApiVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVentas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly AppDbContext context;
        public PublicacionController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            try
            {
                return Ok(context.publicacion.Include(u => u.usuario).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var publicacion = context.publicacion.Include(u => u.usuario).FirstOrDefault(u => u.id == id);
                return Ok(publicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetByI")]
        public ActionResult GetById(int id)
        {

            try
            {
                var publicacion = context.publicacion.FirstOrDefault(publicacion => publicacion.id == id);
                return Ok(publicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Publicacion publicacion)
        {
            try
            {
                context.publicacion.Add(publicacion);
                context.SaveChanges();
                return CreatedAtRoute("GetByI", new { publicacion.id }, publicacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Publicacion publicacion)
        {
            try
            {
                if (publicacion.id == id)
                {
                    context.Entry(publicacion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetByI", new { id = publicacion.id }, publicacion);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        


    }
}
