using System;
using System.Collections.Generic;
using System.Reflection;
using DashProject.Api.Enum;

namespace DashProject.Api.Extension
{
    public static class CodecTypeExtension
    {
        public static EncoderType GetEncoderType(this CodecType codec)
        {
            FieldInfo fi = codec.GetType().GetField(codec.ToString());
            EncoderToUse[] attributes = fi.GetCustomAttributes(typeof(EncoderToUse), false) as EncoderToUse[];
            EncoderType encoder = (attributes != null && attributes.Length > 0) ? attributes[0].Value : EncoderType.none;
            return encoder;
        }

        public static DecoderType GetDecoderType(this CodecType codec)
        {
            FieldInfo fi = codec.GetType().GetField(codec.ToString());
            DecoderToUse[] attributes = fi.GetCustomAttributes(typeof(DecoderToUse), false) as DecoderToUse[];
            DecoderType dencoder = (attributes != null && attributes.Length > 0) ? attributes[0].Value : DecoderType.none;
            return dencoder;
        }
    }
}
