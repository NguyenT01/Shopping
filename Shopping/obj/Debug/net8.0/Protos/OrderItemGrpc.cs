// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/orderItem.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Shopping.API {
  public static partial class OrderItemProto
  {
    static readonly string __ServiceName = "orderItem.OrderItemProto";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.GetItemRequest> __Marshaller_orderItem_GetItemRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.GetItemRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.ItemResponse> __Marshaller_orderItem_ItemResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.ItemResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.OrderItemIdRequest> __Marshaller_orderItem_OrderItemIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.OrderItemIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.ItemListResponse> __Marshaller_orderItem_ItemListResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.ItemListResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.OrderItemCreationRequest> __Marshaller_orderItem_OrderItemCreationRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.OrderItemCreationRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.OrderItemDeletionRequest> __Marshaller_orderItem_OrderItemDeletionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.OrderItemDeletionRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.OrderItemUpdateRequest> __Marshaller_orderItem_OrderItemUpdateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.OrderItemUpdateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.ItemRequest> __Marshaller_orderItem_ItemRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.ItemRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Shopping.API.ItemDecrementResponse> __Marshaller_orderItem_ItemDecrementResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Shopping.API.ItemDecrementResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.GetItemRequest, global::Shopping.API.ItemResponse> __Method_GetItem = new grpc::Method<global::Shopping.API.GetItemRequest, global::Shopping.API.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetItem",
        __Marshaller_orderItem_GetItemRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.OrderItemIdRequest, global::Shopping.API.ItemListResponse> __Method_GetItemsFromOrder = new grpc::Method<global::Shopping.API.OrderItemIdRequest, global::Shopping.API.ItemListResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetItemsFromOrder",
        __Marshaller_orderItem_OrderItemIdRequest,
        __Marshaller_orderItem_ItemListResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.OrderItemCreationRequest, global::Shopping.API.ItemResponse> __Method_CreateOrderItem = new grpc::Method<global::Shopping.API.OrderItemCreationRequest, global::Shopping.API.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateOrderItem",
        __Marshaller_orderItem_OrderItemCreationRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.OrderItemDeletionRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteOrderItem = new grpc::Method<global::Shopping.API.OrderItemDeletionRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteOrderItem",
        __Marshaller_orderItem_OrderItemDeletionRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.OrderItemUpdateRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateOrderItem = new grpc::Method<global::Shopping.API.OrderItemUpdateRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateOrderItem",
        __Marshaller_orderItem_OrderItemUpdateRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.ItemRequest, global::Shopping.API.ItemResponse> __Method_IncreaseQuantityOrderItemBy1 = new grpc::Method<global::Shopping.API.ItemRequest, global::Shopping.API.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IncreaseQuantityOrderItemBy1",
        __Marshaller_orderItem_ItemRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Shopping.API.ItemRequest, global::Shopping.API.ItemDecrementResponse> __Method_DecreaseQuantityOrderItemBy1 = new grpc::Method<global::Shopping.API.ItemRequest, global::Shopping.API.ItemDecrementResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DecreaseQuantityOrderItemBy1",
        __Marshaller_orderItem_ItemRequest,
        __Marshaller_orderItem_ItemDecrementResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Shopping.API.OrderItemReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for OrderItemProto</summary>
    public partial class OrderItemProtoClient : grpc::ClientBase<OrderItemProtoClient>
    {
      /// <summary>Creates a new client for OrderItemProto</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public OrderItemProtoClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for OrderItemProto that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public OrderItemProtoClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected OrderItemProtoClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected OrderItemProtoClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse GetItem(global::Shopping.API.GetItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse GetItem(global::Shopping.API.GetItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> GetItemAsync(global::Shopping.API.GetItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> GetItemAsync(global::Shopping.API.GetItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemListResponse GetItemsFromOrder(global::Shopping.API.OrderItemIdRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetItemsFromOrder(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemListResponse GetItemsFromOrder(global::Shopping.API.OrderItemIdRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetItemsFromOrder, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemListResponse> GetItemsFromOrderAsync(global::Shopping.API.OrderItemIdRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetItemsFromOrderAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemListResponse> GetItemsFromOrderAsync(global::Shopping.API.OrderItemIdRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetItemsFromOrder, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse CreateOrderItem(global::Shopping.API.OrderItemCreationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateOrderItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse CreateOrderItem(global::Shopping.API.OrderItemCreationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> CreateOrderItemAsync(global::Shopping.API.OrderItemCreationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateOrderItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> CreateOrderItemAsync(global::Shopping.API.OrderItemCreationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteOrderItem(global::Shopping.API.OrderItemDeletionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteOrderItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteOrderItem(global::Shopping.API.OrderItemDeletionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteOrderItemAsync(global::Shopping.API.OrderItemDeletionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteOrderItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteOrderItemAsync(global::Shopping.API.OrderItemDeletionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateOrderItem(global::Shopping.API.OrderItemUpdateRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateOrderItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateOrderItem(global::Shopping.API.OrderItemUpdateRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateOrderItemAsync(global::Shopping.API.OrderItemUpdateRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateOrderItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateOrderItemAsync(global::Shopping.API.OrderItemUpdateRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateOrderItem, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse IncreaseQuantityOrderItemBy1(global::Shopping.API.ItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IncreaseQuantityOrderItemBy1(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemResponse IncreaseQuantityOrderItemBy1(global::Shopping.API.ItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IncreaseQuantityOrderItemBy1, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> IncreaseQuantityOrderItemBy1Async(global::Shopping.API.ItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IncreaseQuantityOrderItemBy1Async(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemResponse> IncreaseQuantityOrderItemBy1Async(global::Shopping.API.ItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IncreaseQuantityOrderItemBy1, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemDecrementResponse DecreaseQuantityOrderItemBy1(global::Shopping.API.ItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DecreaseQuantityOrderItemBy1(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Shopping.API.ItemDecrementResponse DecreaseQuantityOrderItemBy1(global::Shopping.API.ItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DecreaseQuantityOrderItemBy1, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemDecrementResponse> DecreaseQuantityOrderItemBy1Async(global::Shopping.API.ItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DecreaseQuantityOrderItemBy1Async(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Shopping.API.ItemDecrementResponse> DecreaseQuantityOrderItemBy1Async(global::Shopping.API.ItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DecreaseQuantityOrderItemBy1, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override OrderItemProtoClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new OrderItemProtoClient(configuration);
      }
    }

  }
}
#endregion
