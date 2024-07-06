using BooksWagonApplication.Models;
using BooksWagonApplication.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BooksWagonApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShopController : ControllerBase
    {
        private readonly BookShopContext _dbContext;


        public BookShopController(BookShopContext _context)
        {
            _dbContext = _context;
        }



       

        [HttpGet]
        [Route("~/api/GetArchitetureBookType")]

        public async Task<IActionResult> GetArchitetureBookType()
        {
            List<ArtsPhotography> artsPhotograph = _dbContext.ArtsPhotographies.ToList();
            List<ArtsPhotographyDatum> artsPhotographType = _dbContext.ArtsPhotographyData.ToList();
            List<int?> bookIds = artsPhotograph.Select(x => x.BookTypeId).ToList();
            try
            {
                List<ArtsPhotographyDatum> GetALlBooks = new List<ArtsPhotographyDatum>();

                foreach (ArtsPhotographyDatum artsType in artsPhotographType)
                {
                    if (bookIds.Contains(artsType.BookTypeId))
                    {
                        GetALlBooks.Add(artsType);
                    }

                }
                return Ok(GetALlBooks);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("~/api/GetArtsArchitetureType")]

        public async Task<IActionResult> GetArtsArchitetureType()
        {
            try
            {
                List<ArtsPhotography> artsPhotographies = _dbContext.ArtsPhotographies.ToList();


                if (artsPhotographies != null)
                {
                    return Ok(artsPhotographies);
                }
                return Ok("they are not books in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("~/api/PostArchitetureBook")]

        public async Task<ActionResult<ArtsPhotography>> PostArtsPhotography(CreateArtPhotographyDTO ArtPhotographyDTO)
        {

            var artsPhotography = new ArtsPhotography
            {
                BookId = ArtPhotographyDTO.BookId,
                BookName = ArtPhotographyDTO.BookName,
                Author = ArtPhotographyDTO.Author,
                Price = ArtPhotographyDTO.Price,
                TotalPrice = ArtPhotographyDTO.TotalPrice,
                Publisher = ArtPhotographyDTO.Publisher,
                ReleaseDate = ArtPhotographyDTO.ReleaseDate,
                Bindingtype = ArtPhotographyDTO.Bindingtype,
                Languagetype = ArtPhotographyDTO.Languagetype,
                TypeOfBook = ArtPhotographyDTO.TypeOfBook,
                SubTypeOfBook = ArtPhotographyDTO.SubTypeOfBook,
                BookTypeId = ArtPhotographyDTO.BookTypeId,
                // BookType = artsPhotographyDatum
            };


            _dbContext.ArtsPhotographies.Add(artsPhotography);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetArchitetureBookType", new { id = artsPhotography.BookTypeId }, artsPhotography);

        }


        [HttpPost]
        [Route("~/api/PostArchitetureBookType")]

        public async Task<ActionResult<ArtsPhotographyDatum>> PostArchitetureBookType(CreateArtPhotographyTypeDTO ArtsPhtographyTypeDTO)
        {
            var artsPhotographyDatum = new ArtsPhotographyDatum
            {
                BookTypeId = ArtsPhtographyTypeDTO.BookTypeId,
                TypeOfBook = ArtsPhtographyTypeDTO.TypeOfBook,
                SubTypeOfBook = ArtsPhtographyTypeDTO.SubTypeOfBook,

            };

            _dbContext.ArtsPhotographyData.Add(artsPhotographyDatum);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetArchitetureBookType", new { id = artsPhotographyDatum.BookTypeId }, artsPhotographyDatum);

        }


    }
}
