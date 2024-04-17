using Examen.Application.Commands.Medicina;
using Examen.Application.Commands.Usuario;
using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using Examen.Application.Queries.Medicina;
using Examen.Application.Queries.Usuario;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Web.Http.Results;

namespace Examen.API.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        ///<summary>
        ///Queries 
        ///</summary>
        private readonly ImedicinaQueries _IMedicinaQueries;
        private readonly ICommandsMedicine _ICommandsMedicine;
        ///<summary>
        ///Commands
        ///</summary>        
        ///<summary>
        ///Constructor para la inyeccion
        ///</summary>
        ///<param name="IMedicinaQueries"></param>
        ///<param name="IMedicinaCommands"></param>

        public MedicamentoController(
            ImedicinaQueries IMedicinaQueries,
            ICommandsMedicine IMedicinaCommands

            )
        {

            this._IMedicinaQueries = IMedicinaQueries;
            this._ICommandsMedicine = IMedicinaCommands;
        }

        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpGet("GetMedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseMedicine>> GetMedicine([FromQuery] RequestPaginado request)
        {
            try
            {
                ResponseMedicine oResponse = new ResponseMedicine();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _IMedicinaQueries.GetMedicine(request.pageNumber, request.pageSize);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }


        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpPost("GetMedicinebyfiltro")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseMedicine>> GetMedicineF(RequestMedicine request)
        {
            try
            {
                ResponseMedicine oResponse = new ResponseMedicine();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _IMedicinaQueries.GetMedicineByFiltro(request);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }



        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpPost("AddMedicine")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddMedicine>> AddMedicine(RequestAddMedicine request)
        {
            try
            {
                ResponseAddMedicine oResponse = new ResponseAddMedicine();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _ICommandsMedicine.AddMedicina(request);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }


        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpPatch("ModMedicina")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddMedicine>> ModUsuarios(RequestModMedicine request)
        {
            try
            {
                ResponseAddMedicine oResponse = new ResponseAddMedicine();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _ICommandsMedicine.ModMedicina(request);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }


        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpDelete("DelMedicina")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddMedicine>> DelUsuarios(string request)
        {
            try
            {
                ResponseAddMedicine oResponse = new ResponseAddMedicine();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _ICommandsMedicine.DelMedicina(request);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }
    }
}
