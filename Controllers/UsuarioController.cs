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
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsuarioController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            try
            {
                return Ok(context.usuario.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {

            try
            {
                var usuario = context.usuario.FirstOrDefault(usuario => usuario.id == id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                context.usuario.Add(usuario);
                context.SaveChanges();
                return CreatedAtRoute("GetById", new { usuario.id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.id == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetById", new { id = usuario.id }, usuario);
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
