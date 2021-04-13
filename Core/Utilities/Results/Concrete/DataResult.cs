﻿using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<TEntity> : Result, IDataResult<TEntity>
    {
        public DataResult(TEntity data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(TEntity data,bool success):base(success)
        {
            Data = data;
        }
        public DataResult(TEntity data,bool success,string message,List<OperationClaim> claims) : base(success, message)
        {
            Data = data;
            Claims = claims;
        }
        public TEntity Data { get; }

        public List<OperationClaim> Claims { get; }
    }
}