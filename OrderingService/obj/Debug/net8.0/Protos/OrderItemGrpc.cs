// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/orderItem.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace OrderingService.Protos {
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
    static readonly grpc::Marshaller<global::OrderingService.Protos.GetItemRequest> __Marshaller_orderItem_GetItemRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.GetItemRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.ItemResponse> __Marshaller_orderItem_ItemResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.ItemResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.OrderItemIdRequest> __Marshaller_orderItem_OrderItemIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.OrderItemIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.ItemListResponse> __Marshaller_orderItem_ItemListResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.ItemListResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.OrderItemCreationRequest> __Marshaller_orderItem_OrderItemCreationRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.OrderItemCreationRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.OrderItemDeletionRequest> __Marshaller_orderItem_OrderItemDeletionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.OrderItemDeletionRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.OrderItemUpdateRequest> __Marshaller_orderItem_OrderItemUpdateRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.OrderItemUpdateRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.ItemRequest> __Marshaller_orderItem_ItemRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.ItemRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::OrderingService.Protos.ItemDecrementResponse> __Marshaller_orderItem_ItemDecrementResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::OrderingService.Protos.ItemDecrementResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.GetItemRequest, global::OrderingService.Protos.ItemResponse> __Method_GetItem = new grpc::Method<global::OrderingService.Protos.GetItemRequest, global::OrderingService.Protos.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetItem",
        __Marshaller_orderItem_GetItemRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.OrderItemIdRequest, global::OrderingService.Protos.ItemListResponse> __Method_GetItemsFromOrder = new grpc::Method<global::OrderingService.Protos.OrderItemIdRequest, global::OrderingService.Protos.ItemListResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetItemsFromOrder",
        __Marshaller_orderItem_OrderItemIdRequest,
        __Marshaller_orderItem_ItemListResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.OrderItemCreationRequest, global::OrderingService.Protos.ItemResponse> __Method_CreateOrderItem = new grpc::Method<global::OrderingService.Protos.OrderItemCreationRequest, global::OrderingService.Protos.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateOrderItem",
        __Marshaller_orderItem_OrderItemCreationRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.OrderItemDeletionRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteOrderItem = new grpc::Method<global::OrderingService.Protos.OrderItemDeletionRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteOrderItem",
        __Marshaller_orderItem_OrderItemDeletionRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.OrderItemUpdateRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateOrderItem = new grpc::Method<global::OrderingService.Protos.OrderItemUpdateRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateOrderItem",
        __Marshaller_orderItem_OrderItemUpdateRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemResponse> __Method_IncreaseQuantityOrderItemBy1 = new grpc::Method<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IncreaseQuantityOrderItemBy1",
        __Marshaller_orderItem_ItemRequest,
        __Marshaller_orderItem_ItemResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemDecrementResponse> __Method_DecreaseQuantityOrderItemBy1 = new grpc::Method<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemDecrementResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DecreaseQuantityOrderItemBy1",
        __Marshaller_orderItem_ItemRequest,
        __Marshaller_orderItem_ItemDecrementResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::OrderingService.Protos.OrderItemReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of OrderItemProto</summary>
    [grpc::BindServiceMethod(typeof(OrderItemProto), "BindService")]
    public abstract partial class OrderItemProtoBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::OrderingService.Protos.ItemResponse> GetItem(global::OrderingService.Protos.GetItemRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::OrderingService.Protos.ItemListResponse> GetItemsFromOrder(global::OrderingService.Protos.OrderItemIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::OrderingService.Protos.ItemResponse> CreateOrderItem(global::OrderingService.Protos.OrderItemCreationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteOrderItem(global::OrderingService.Protos.OrderItemDeletionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateOrderItem(global::OrderingService.Protos.OrderItemUpdateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::OrderingService.Protos.ItemResponse> IncreaseQuantityOrderItemBy1(global::OrderingService.Protos.ItemRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::OrderingService.Protos.ItemDecrementResponse> DecreaseQuantityOrderItemBy1(global::OrderingService.Protos.ItemRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(OrderItemProtoBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetItem, serviceImpl.GetItem)
          .AddMethod(__Method_GetItemsFromOrder, serviceImpl.GetItemsFromOrder)
          .AddMethod(__Method_CreateOrderItem, serviceImpl.CreateOrderItem)
          .AddMethod(__Method_DeleteOrderItem, serviceImpl.DeleteOrderItem)
          .AddMethod(__Method_UpdateOrderItem, serviceImpl.UpdateOrderItem)
          .AddMethod(__Method_IncreaseQuantityOrderItemBy1, serviceImpl.IncreaseQuantityOrderItemBy1)
          .AddMethod(__Method_DecreaseQuantityOrderItemBy1, serviceImpl.DecreaseQuantityOrderItemBy1).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, OrderItemProtoBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetItem, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.GetItemRequest, global::OrderingService.Protos.ItemResponse>(serviceImpl.GetItem));
      serviceBinder.AddMethod(__Method_GetItemsFromOrder, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.OrderItemIdRequest, global::OrderingService.Protos.ItemListResponse>(serviceImpl.GetItemsFromOrder));
      serviceBinder.AddMethod(__Method_CreateOrderItem, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.OrderItemCreationRequest, global::OrderingService.Protos.ItemResponse>(serviceImpl.CreateOrderItem));
      serviceBinder.AddMethod(__Method_DeleteOrderItem, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.OrderItemDeletionRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteOrderItem));
      serviceBinder.AddMethod(__Method_UpdateOrderItem, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.OrderItemUpdateRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateOrderItem));
      serviceBinder.AddMethod(__Method_IncreaseQuantityOrderItemBy1, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemResponse>(serviceImpl.IncreaseQuantityOrderItemBy1));
      serviceBinder.AddMethod(__Method_DecreaseQuantityOrderItemBy1, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::OrderingService.Protos.ItemRequest, global::OrderingService.Protos.ItemDecrementResponse>(serviceImpl.DecreaseQuantityOrderItemBy1));
    }

  }
}
#endregion
