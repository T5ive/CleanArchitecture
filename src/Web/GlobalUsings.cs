global using System.Reflection;
global using System.Security.Claims;
global using Ardalis.GuardClauses;
global using Azure.Identity;
global using CleanArchitecture.Application.Share.Common.Exceptions;
global using CleanArchitecture.Application.Share.Common.Interfaces;
global using CleanArchitecture.Application.Share.Common.Models;
global using CleanArchitecture.Infrastructure.Data;
global using CleanArchitecture.Web.Infrastructure;
global using CleanArchitecture.Web.Services;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
#if (UseApiOnly)
global using NSwag;
global using NSwag.Generation.Processors.Security;
#endif

global using ZymLabs.NSwag.FluentValidation;
