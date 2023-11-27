using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeniorChallenge.Consts;
using SeniorChallenge.Entities;
using SeniorChallenge.Services;

namespace SeniorChallenge.Controllers
{
    /// <summary>
    /// The endpoint to work with person entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public class PersonController : ControllerBase
    {
        private readonly PersonService service = new();
        private const string UNKNOW_ISSUE = "There was an unknown inclusion failure, contact a system administrator";

        /// <summary>
        /// Include a person on API.
        /// </summary>
        /// <param name="person">The person who will be included.</param>
        /// <returns>Person with updated id.</returns>
        [HttpPost]
        [Authorize(Roles = ConstRoles.CREATE_PERSON)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Person> Post(Person person)
        {
            Person obj;
            try
            {
                obj = service.Insert(person);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return obj.Id != 0 ? Created("api/person - Post", obj) : BadRequest(UNKNOW_ISSUE);
        }

        /// <summary>
        /// Update a person on API.
        /// </summary>
        /// <param name="person">The person who will be updated.</param>
        /// <returns>Person with updated infos.</returns>
        [HttpPut]
        [Authorize(Roles = ConstRoles.UPDATE_PERSON)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> Update(Person person)
        {
            Person obj;
            try
            {
                obj = service.Update(person);
                if (obj == null)
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return obj.Id != 0 ? Ok(obj) : BadRequest(UNKNOW_ISSUE);
        }

        /// <summary>
        /// Get a single person filtered by id.
        /// </summary>
        /// <param name="id">The id of the person searched.</param>
        /// <returns>The person requested.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = ConstRoles.READ_PERSON)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> GetSingle(int id)
        {
            Person obj = service.GetSingle(id);
            return obj != null && obj.Id != 0 ? Ok(obj) : NotFound();
        }

        /// <summary>
        /// Get a collection of persons filtered by UF.
        /// </summary>
        /// <param name="uf">The acronym of the person's state.</param>
        /// <returns>A collection of persons filtered by UF.</returns>
        [HttpGet("UF/{uf}")]
        [Authorize(Roles = ConstRoles.READ_PERSON)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Person>> GetFromUF(string uf)
        {
            List<Person> obj = service.GetByUf(uf);
            return obj.Count != 0 ? Ok(obj) : NoContent();
        }

        /// <summary>
        /// Get a collection of persons without filters.
        /// </summary>
        /// <returns>A collection of persons.</returns>
        [HttpGet()]
        [Authorize(Roles = ConstRoles.READ_PERSON)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Person>> GetAll()
        {
            List<Person> obj = service.GetAll();
            return obj.Count != 0 ? Ok(obj) : NoContent();
        }

        /// <summary>
        /// Delete a single person filtered by id.
        /// </summary>
        /// <param name="id">The id of the person to delete.</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = ConstRoles.DELETE_PERSON)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            bool result;
            try
            {
                result = service.Delete(id);
                if (!result)
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
