﻿using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  readonly IRepository<Contributor> _repository = Substitute.For<IRepository<Contributor>>();
  readonly IMediator _mediator = Substitute.For<IMediator>();
  readonly ILogger<DeleteContributorService> _logger = Substitute.For<ILogger<DeleteContributorService>>();

  readonly DeleteContributorService _service;

  public DeleteContributorService_DeleteContributor() => _service = new DeleteContributorService(_repository, _mediator, _logger);
  {
    _service = new DeleteContributorService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    Ardalis.Result.Result result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
