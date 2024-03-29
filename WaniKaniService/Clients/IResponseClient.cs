﻿using WaniKaniService.Models;

namespace WaniKaniService;

public interface IResponseClient<T>
{
    Task<Response<T>> GetAsync();
}

public interface IResponseClient
{
    Task<object> GetAsync();
}