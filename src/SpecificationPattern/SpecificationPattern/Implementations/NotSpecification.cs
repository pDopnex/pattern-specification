﻿using System;
using System.Linq.Expressions;
using SpecificationPattern.Interfaces;

namespace SpecificationPattern.Implementations
{
    public class NotSpecification<TEntity> : Specification<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;

        public NotSpecification(ISpecification<TEntity> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            var expression = _specification.ToExpression();

            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Not(expression.Body),
                expression.Parameters);
        }
    }
}