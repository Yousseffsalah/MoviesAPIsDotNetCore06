using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BAL.Interfaces.UnitOfWork;
using Movies.BAL.Repository;

namespace Movies.PL.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ApiBaseController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


    }
}
