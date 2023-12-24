// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Basket.API.Data.BasketContext.#ctor(StackExchange.Redis.ConnectionMultiplexer)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Basket.API.Repositories.BasketRepository.#ctor(Basket.API.Data.Interfaces.IBasketContext)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Basket.API.Controllers.BasketController.#ctor(Basket.API.Repositories.Interfaces.IBasketRepository)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Basket.API.Controllers.BasketController.#ctor(Basket.API.Repositories.Interfaces.IBasketRepository,EventBusRabbitMQ.Producer.EventBusRabbitMQProducer,AutoMapper.IMapper)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Basket.API.Controllers.BasketController.#ctor(Basket.API.Repositories.Interfaces.IBasketRepository,EventBusRabbitMQ.Producer.EventBusRabbitMQProducer,AutoMapper.IMapper,Basket.API.GrpcServices.DiscountGrpcService)")]
