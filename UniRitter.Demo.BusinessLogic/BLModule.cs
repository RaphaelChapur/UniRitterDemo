using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using UniRitter.Demo.DomainModel;

namespace UniRitter.Demo.BusinessLogic
{
    public class BLModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IBusinessObject<>))
                .To(typeof(BusinessObject<>));

            this.Bind<ILivroBO>()
                .To<LivroBO>();
        }
    }
}
