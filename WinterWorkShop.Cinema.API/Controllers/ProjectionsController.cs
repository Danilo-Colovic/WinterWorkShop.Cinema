﻿using Microsoft.AspNetCore.Mvc;
using WinterWorkShop.Cinema.Data.Repositories;
using WinterWorkShop.Cinema.Domain.Responses;

namespace WinterWorkShop.Cinema.API.Controllers
{
    [ApiController]
    [Route("projections")]

    public class ProjectionsController : BaseController
    {
            public readonly IProjectionRepository _projectionRepository;

        public ProjectionsController(IProjectionRepository projectionRepository)
        {
            _projectionRepository = projectionRepository;
        }

        [HttpGet()]
        public List<GetAllProjectionsResponses> GetProjections()
        {
            var projections = _projectionRepository.GetAllProjections();

            var result = new List<GetAllProjectionsResponses>();

            foreach (var projection in projections)
            {
                result.Add(new GetAllProjectionsResponses
                {
                    Id = projection.Id,
                    Date = projection.Date
                });
            }

            return result;
        }
    }
}
