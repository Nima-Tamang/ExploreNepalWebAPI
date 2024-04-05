//namespace ExploreNepalWebAPI.Facebook
//{
//    public class FacebookBackChannelHandler : HttpClient
//    {
//        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
//        {
//            if (!request.RequestUri.AbsolutePath.Contains('/oauth'))
//            {
//                request.RequestUri = new Uri(
//                    request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
//            }
//            return await base.SendAsync(request, cancellationToken);
//        }
//    }
//}
