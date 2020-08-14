using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MSU_Case_LostAndFound.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : Controller
    {
        private IAnimalsRepository repository;

        public AnimalsController(IAnimalsRepository repository)
        {
            this.repository = repository;
        }

        #region Query action methods

        // GET api/productsuggestions?partialName=FC
        [HttpGet]
        public ActionResult<IEnumerable<Animals>> ProductSuggestionsLike(string partialName)
        {
            if (String.IsNullOrEmpty(partialName))
            {
                return Ok(repository.GetAll());
            }
            else
            {
                return Ok(repository.GetLike(partialName));
            }
        }

        #endregion

        #region Modify action methods


        // PUT api/productsuggestions/2
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Animals item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else if (repository.Update(item))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/productsuggestions/2
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (repository.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        #endregion
    }
}

