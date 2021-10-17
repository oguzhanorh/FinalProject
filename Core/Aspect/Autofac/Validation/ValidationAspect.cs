using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ASPECT
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding (savunma kodlaması)
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflection : çalışma anında bir şeyleri çalıştırmayı sağlıyor 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //productvalidator çalışma tipini bul  demek.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //parametrelerini bul ilgili metodun parametrelerini yani. IResult Add
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
