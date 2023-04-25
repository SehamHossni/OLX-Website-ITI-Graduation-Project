using AutoMapper;
using BLL.Interface;
using BLL.Repository;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.DTO;
using Talabat.Errors;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        //private readonly IGenericRepo<Comment> genericRepo;
        private readonly IMapper mapper;
        private readonly commentsrepos commentsrepos;

        public CommentController(IMapper mapper,commentsrepos _comments)
        {
            
            this.mapper = mapper;
            this.commentsrepos = _comments;
        }



        /*[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Comment>> Get(int id)
        {

            var comments = await genericRepo.GetById(id);
            var data = mapper.Map<Comment, CommentDTO>(comments);

            return Ok(data);
        }*/



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Comment>> ADD(CommentDTO commentdto)
        {

            Comment comment = new Comment();
            comment.Id = commentdto.Id;
            comment.Email = commentdto.Email;
            comment.ProductID = commentdto.ProductID;
            comment.Content = commentdto.Content;

            await commentsrepos.Add(comment);

            return Ok(comment);
        }



        /*[HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            Comment comments = await genericRepo.GetById(id);

            genericRepo.Delete(comments);

            return Ok(comments);
        }*/
    }
}
