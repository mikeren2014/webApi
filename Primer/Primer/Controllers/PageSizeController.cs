using Primer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "http://apress.com";

        //Sychronous will block the server handle other request
        //public async Task<long> GetPageSize(CancellationToken cToken)
        //{
        //    WebClient wc = new WebClient();
        //    Stopwatch sw = Stopwatch.StartNew();
        //    byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //    return apressData.LongLength;
        //}

        //Asynchronous can improve the speed of the whole server performance, bu will lower indivaduel request performance
        public async Task<long> GetPageSize(CancellationToken cToken)
        {
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
            Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
            return apressData.LongLength;
        }

        //To show the usage of the cancel token
        //public async Task<long> GetPageSize(CancellationToken cToken)
        //{
        //    WebClient wc = new WebClient();
        //    Stopwatch sw = Stopwatch.StartNew();
        //    List<long> results = new List<long>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (!cToken.IsCancellationRequested)
        //        {
        //            Debug.WriteLine("Making Request: {0}", i);
        //            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
        //            results.Add(apressData.LongLength);
        //        }
        //        else
        //        {
        //            Debug.WriteLine("Cancelled");
        //            return 0;
        //        }
        //    }
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //    return (long)results.Average();
        //}

        //Demostrate how to create a task to do with a serias of synchronous things
        //public Task<long> GetPageSize2(CancellationToken cToken)
        //{
        //    return Task<long>.Factory.StartNew(() =>
        //    {
        //        WebClient wc = new WebClient();
        //        Stopwatch sw = Stopwatch.StartNew();
        //        List<long> results = new List<long>();
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (!cToken.IsCancellationRequested)
        //            {
        //                Debug.WriteLine("Making Request: {0}", i);
        //                results.Add(wc.DownloadData(TargetUrl).LongLength);
        //            }
        //            else
        //            {
        //                Debug.WriteLine("Cancelled");
        //                return 0;
        //            }
        //        }
        //        Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //        return (long)results.Average();
        //    });
        //}

        public Task PostUrl(string newUrl, CancellationToken cToken)
        {
            TargetUrl = newUrl;
            return Task.FromResult<object>(null);
        }
    }
}
