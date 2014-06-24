using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyNCrunch
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline(
                (ctx, ex) =>
                {
                    Console.Write(ex);
                    return null;
                });
            base.RequestStartup(container, pipelines, context);
        }
    }
}