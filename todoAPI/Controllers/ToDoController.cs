using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoAPI.Data;
using todoAPI.Models;

namespace todoAPI.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IRepository _rep;

        public ToDoController(IRepository Rep)
        {
            _rep = Rep;
        }
        [HttpGet] 
        public async Task<IActionResult> Get(){
            try{

            var result = await _rep.GetAllToDoAsync();
            return Ok(result);

            }
            catch(Exception Ex)
            {
                return BadRequest($"Erro:{Ex.Message}");
            }
           
        }
        [HttpGet("{Id}")] 
        public async Task<IActionResult> GetById(int Id){
            try{

            var result = await _rep.GetToDoAsyncById(Id);
            return Ok(result);

            }
            catch(Exception Ex)
            {
                return BadRequest($"Erro:{Ex.Message}");
            }
           
        }
         [HttpPost] 
        public async Task<IActionResult> post(ToDo M){
            try{

            _rep.Add(M);
            if(await _rep.SaveChangesAsync())
            {
             return Ok(new {message = "Cadastro Realizado com sucesso"});
            }
            

            }
            catch(Exception Ex)
            {
                return BadRequest($"Erro:{Ex.Message}");
            }
           return BadRequest("Erro");
        }
          [HttpPut("{Id}")] 
        public async Task<IActionResult> put(int Id,ToDo M){
            try{

            var result = await _rep.GetToDoAsyncById(Id);
            if(result == null) return NotFound("Tarefa nao encontrada");
            _rep.Update(M);
            if(await _rep.SaveChangesAsync())
            {
             return Ok(new { message ="Alteração Realizada com sucesso"});
            }
            

            }
            catch(Exception Ex)
            {
                return BadRequest($"Erro:{Ex.Message}");
            }
           return BadRequest("Erro");
        }

         [HttpDelete("{Id}")] 
        public async Task<IActionResult> delete(int Id){
            try{

            var result = await _rep.GetToDoAsyncById(Id);
            if(result == null) return NotFound("Tarefa nao encontrada");
            _rep.Delete(result);
            if(await _rep.SaveChangesAsync())
            {
             return Ok(new { message ="Exclusão Realizada com sucesso."});
            }
            

            }
            catch(Exception Ex)
            {
                return BadRequest($"Erro:{Ex.Message}");
            }
           return BadRequest("Erro");
        }
        
    }
}