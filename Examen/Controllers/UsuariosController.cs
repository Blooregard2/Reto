using Examen.Application.Commands.Usuario;
using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Usuario;
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
    public class UsuariosController : ControllerBase
    {
        ///<summary>
        ///Queries 
        ///</summary>
        private readonly IUsuarioQueries _iUsuarioQueries;
        private readonly IUsuarioCommands _iUsuarioCommands;
        ///<summary>
        ///Commands
        ///</summary>        
        ///<summary>
        ///Constructor para la inyeccion
        ///</summary>
        ///<param name="iUsuarioQueries"></param>
        ///<param name="iUsuarioCommand"></param>

        public UsuariosController(
            IUsuarioQueries iUsuarioQueries,
            IUsuarioCommands iUsuarioCommands

            )
        {

            this._iUsuarioQueries = iUsuarioQueries;
            this._iUsuarioCommands = iUsuarioCommands;
        }

        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ResponseLogin> GetLogin(RequestLogin request)
        {
            try
            {
                ResponseLogin oResponse = new ResponseLogin();
                if (!ModelState.IsValid)
                {
                    return BadRequest(); }
                oResponse =  _iUsuarioQueries.GetResponseLogin(request);
                return Ok(oResponse);
            } catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#", ""));
            }

        }

        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpGet("GetUsuarios")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseUser>> GetUsers([FromQuery] RequestPaginado request)
        {
            try
            {
                ResponseUser oResponse = new ResponseUser();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _iUsuarioQueries.GetUsers(request.pageNumber , request.pageSize);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                if (!(ex.Message.Contains("#"))) { return StatusCode(500, ex.Message); }
                return NotFound(ex.Message.Replace("#",""));
            }

        }


        ///<summary>
        ///Metodo de Login de Usuario 
        ///</summary>
        ///<returns></returns>
        [HttpPost("GetUsuariosbyfiltro")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseUser>> GetUsers(RequestUsuario request)
        {
            try
            {
                ResponseUser oResponse = new ResponseUser();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _iUsuarioQueries.GetUsersbyfiltro(request);
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
        [HttpPost("AddUsuarios")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddUsuario>> AddUsuarios(RequestAddUsuario request)
        {
            try
            {
                ResponseAddUsuario oResponse = new ResponseAddUsuario();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _iUsuarioCommands.AddUsuario(request);
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
        [HttpPatch("ModUsuarios")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddUsuario>> ModUsuarios(RequestModUsuario request)
        {
            try
            {
                ResponseAddUsuario oResponse = new ResponseAddUsuario();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _iUsuarioCommands.ModUsuario(request);
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
        [HttpDelete("DelUsuarios")] //Se manda un metodo Post por la informacion de filtros y el paginado
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseAddUsuario>> DelUsuarios(string request)
        {
            try
            {
                ResponseAddUsuario oResponse = new ResponseAddUsuario();
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                oResponse = await _iUsuarioCommands.DelUsuario(request);
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
