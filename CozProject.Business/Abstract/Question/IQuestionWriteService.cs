﻿using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IQuestionWriteService
{
    Task<IResult> AddAsync(Question question);
    Task<IResult> UpdateAsync(Question question);
    IResult Delete(Question question);
    Task<int> SaveAsync();
}
