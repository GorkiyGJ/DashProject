<%@ WebHandler Language="C#" Class="controller" %>

using System;
using System.Web;
using System.IO;
using System.Net;
using DashProject.Utils;
using DashProject.Repository;
using DashProject.Api;

public class controller : IHttpHandler {

    enum RequestType
    {
        msegment = 1,
        init = 2,
        mpd = 3
    }
    
    public void ProcessRequest (HttpContext context) {
        
        
        int mediaId = Converter.ToInt32(context.Request["mid"]);
        if (mediaId == -1)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return;
        }
        
        RequestType type;
        if (context.Request["type"] == null || !Enum.TryParse<RequestType>(context.Request["type"], out type))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        if (type == RequestType.mpd)
        {
            string manifestFilePath = CoreApi.Get_Manifest_FilePath(mediaId);
            if (!File.Exists(manifestFilePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
            context.Response.ContentType = "application/dash+xml";
            context.Response.TransmitFile(manifestFilePath);
            return;
        }
        
        int dashmId = Converter.ToInt32(context.Request["did"]);
        
        if (dashmId == -1)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }
        
        if (type == RequestType.init)
        {
            string initSegmentFilePath = CoreApi.Get_DashInitSegment_FilePath(mediaId, dashmId);
            if (!File.Exists(initSegmentFilePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
            context.Response.ContentType = "video/mp4";
            context.Response.TransmitFile(initSegmentFilePath);    
            return;
        }

        if (type == RequestType.msegment)
        {
            int time;
            if (context.Request["time"] == null || !int.TryParse(context.Request["time"], out time))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            int? segmentId = null;

            Factory.DashMediaSegment.GetId_By_DashMediaId_DecodeTimeTS(dashmId, time, ref segmentId);


            if (!segmentId.HasValue)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                return;
            }

            string mediaFilePath = CoreApi.Get_DashSegment_FilePath(dashmId, segmentId.Value);
            if (!File.Exists(mediaFilePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
            context.Response.ContentType = "video/mp4";
            context.Response.TransmitFile(mediaFilePath);
            return;
            
            
            /*iFragmentInfo fragmentInfo = Factory.iFragmentInfo.GetBy_Time_MediaResourceId(time, 1)[0];
            string mediaFilePath = MediaFileUtils.GetMediaFilePath(mediaId, mediaType, fragmentInfo.MediaFileName);
            if (!File.Exists(mediaFilePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
            context.Response.ContentType = "video/mp4";
            context.Response.TransmitFile(mediaFilePath, (long)fragmentInfo.Offset, (long)fragmentInfo.Size);
            return;*/
        }   
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}