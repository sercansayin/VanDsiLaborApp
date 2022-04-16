﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VanDsi.Core.DTOs;
using VanDsi.Core.Repositories;
using VanDsi.Core.Services;
using VanDsi.Core.UnitOfWorks;
using VanDsi.Service.Exceptions;

namespace VanDsi.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasEntity = await _repository.GetByIdAsync(id);

            if (hasEntity == null)
                throw new NotFoundException($"{typeof(T).Name}({id}) not found");

            return hasEntity;
        }

        public async Task<CustomResponseDto<IEnumerable<T>>> GetAllAsync()
        {
            var tListAsync = await _repository.GetAll().ToListAsync();
            return CustomResponseDto<IEnumerable<T>>.Success(200,tListAsync);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
