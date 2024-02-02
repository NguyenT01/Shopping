// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/orderItem.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OrderingService.Protos {

  /// <summary>Holder for reflection information generated from Protos/orderItem.proto</summary>
  public static partial class OrderItemReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/orderItem.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OrderItemReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZQcm90b3Mvb3JkZXJJdGVtLnByb3RvEglvcmRlckl0ZW0aHmdvb2dsZS9w",
            "cm90b2J1Zi93cmFwcGVycy5wcm90bxobZ29vZ2xlL3Byb3RvYnVmL2VtcHR5",
            "LnByb3RvGh9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3RvIjQKDkdl",
            "dEl0ZW1SZXF1ZXN0Eg8KB09yZGVySWQYASABKAkSEQoJUHJvZHVjdElkGAIg",
            "ASgJIkQKDEl0ZW1SZXNwb25zZRIPCgdPcmRlcklkGAEgASgJEhEKCVByb2R1",
            "Y3RJZBgCIAEoCRIQCghRdWFudGl0eRgDIAEoBTJPCg5PcmRlckl0ZW1Qcm90",
            "bxI9CgdHZXRJdGVtEhkub3JkZXJJdGVtLkdldEl0ZW1SZXF1ZXN0Ghcub3Jk",
            "ZXJJdGVtLkl0ZW1SZXNwb25zZUIZqgIWT3JkZXJpbmdTZXJ2aWNlLlByb3Rv",
            "c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OrderingService.Protos.GetItemRequest), global::OrderingService.Protos.GetItemRequest.Parser, new[]{ "OrderId", "ProductId" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OrderingService.Protos.ItemResponse), global::OrderingService.Protos.ItemResponse.Parser, new[]{ "OrderId", "ProductId", "Quantity" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetItemRequest : pb::IMessage<GetItemRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetItemRequest> _parser = new pb::MessageParser<GetItemRequest>(() => new GetItemRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetItemRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OrderingService.Protos.OrderItemReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetItemRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetItemRequest(GetItemRequest other) : this() {
      orderId_ = other.orderId_;
      productId_ = other.productId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetItemRequest Clone() {
      return new GetItemRequest(this);
    }

    /// <summary>Field number for the "OrderId" field.</summary>
    public const int OrderIdFieldNumber = 1;
    private string orderId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string OrderId {
      get { return orderId_; }
      set {
        orderId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ProductId" field.</summary>
    public const int ProductIdFieldNumber = 2;
    private string productId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ProductId {
      get { return productId_; }
      set {
        productId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetItemRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetItemRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OrderId != other.OrderId) return false;
      if (ProductId != other.ProductId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (OrderId.Length != 0) hash ^= OrderId.GetHashCode();
      if (ProductId.Length != 0) hash ^= ProductId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (OrderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderId);
      }
      if (ProductId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ProductId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (OrderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderId);
      }
      if (ProductId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ProductId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (OrderId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OrderId);
      }
      if (ProductId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ProductId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetItemRequest other) {
      if (other == null) {
        return;
      }
      if (other.OrderId.Length != 0) {
        OrderId = other.OrderId;
      }
      if (other.ProductId.Length != 0) {
        ProductId = other.ProductId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            OrderId = input.ReadString();
            break;
          }
          case 18: {
            ProductId = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            OrderId = input.ReadString();
            break;
          }
          case 18: {
            ProductId = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ItemResponse : pb::IMessage<ItemResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ItemResponse> _parser = new pb::MessageParser<ItemResponse>(() => new ItemResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ItemResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OrderingService.Protos.OrderItemReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemResponse(ItemResponse other) : this() {
      orderId_ = other.orderId_;
      productId_ = other.productId_;
      quantity_ = other.quantity_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ItemResponse Clone() {
      return new ItemResponse(this);
    }

    /// <summary>Field number for the "OrderId" field.</summary>
    public const int OrderIdFieldNumber = 1;
    private string orderId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string OrderId {
      get { return orderId_; }
      set {
        orderId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ProductId" field.</summary>
    public const int ProductIdFieldNumber = 2;
    private string productId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ProductId {
      get { return productId_; }
      set {
        productId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Quantity" field.</summary>
    public const int QuantityFieldNumber = 3;
    private int quantity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Quantity {
      get { return quantity_; }
      set {
        quantity_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ItemResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ItemResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OrderId != other.OrderId) return false;
      if (ProductId != other.ProductId) return false;
      if (Quantity != other.Quantity) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (OrderId.Length != 0) hash ^= OrderId.GetHashCode();
      if (ProductId.Length != 0) hash ^= ProductId.GetHashCode();
      if (Quantity != 0) hash ^= Quantity.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (OrderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderId);
      }
      if (ProductId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ProductId);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (OrderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderId);
      }
      if (ProductId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ProductId);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (OrderId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OrderId);
      }
      if (ProductId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ProductId);
      }
      if (Quantity != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ItemResponse other) {
      if (other == null) {
        return;
      }
      if (other.OrderId.Length != 0) {
        OrderId = other.OrderId;
      }
      if (other.ProductId.Length != 0) {
        ProductId = other.ProductId;
      }
      if (other.Quantity != 0) {
        Quantity = other.Quantity;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            OrderId = input.ReadString();
            break;
          }
          case 18: {
            ProductId = input.ReadString();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            OrderId = input.ReadString();
            break;
          }
          case 18: {
            ProductId = input.ReadString();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
