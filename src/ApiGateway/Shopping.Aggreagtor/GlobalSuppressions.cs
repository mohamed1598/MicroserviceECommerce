// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Shopping.Aggregator.Services.CatalogService.#ctor(System.Net.Http.HttpClient)")]
[assembly: SuppressMessage("Performance", "CA1869:Cache and reuse 'JsonSerializerOptions' instances", Justification = "<Pending>", Scope = "member", Target = "~M:Shopping.Aggregator.HttpClientExtensions.ReadContentAs``1(System.Net.Http.HttpResponseMessage)~System.Threading.Tasks.Task{``0}")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Shopping.Aggregator.Services.BasketService.#ctor(System.Net.Http.HttpClient)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Shopping.Aggregator.Services.OrderService.#ctor(System.Net.Http.HttpClient)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>", Scope = "member", Target = "~M:Shopping.Aggregator.Controllers.ShoppingController.#ctor(Shopping.Aggregator.Services.ICatalogService,Shopping.Aggregator.Services.IBasketService,Shopping.Aggregator.Services.IOrderService)")]
