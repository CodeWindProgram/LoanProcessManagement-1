using AutoMapper;
using Castle.Core.Logging;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesList;
using LoanProcessManagement.Application.Profiles;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Application.UnitTests.Mocks;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanProcessManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        private readonly Mock<ILogger<GetCategoriesListQueryHandler>> _logger;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
            _logger = new Mock<ILogger<GetCategoriesListQueryHandler>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object, _logger.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<CategoryListVm>>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
