const PROTO_PATH = __dirname + '/service.proto';

const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');

let packageDefinition = protoLoader.loadSync(
    PROTO_PATH,
    {keepCase: true,
     longs: String,
     enums: String,
     defaults: true,
     oneofs: true
    });

let service_proto = grpc.loadPackageDefinition(packageDefinition).service;

function getRecycleCoin(call, callback) {
  console.log(call.request.carbonValue);
  callback(null, 
    {
      recycleCoinValue:(call.request.carbonValue/100000000).toString()
    });
}

function main() {
  let server = new grpc.Server();
  server.addService(service_proto.grpcService.service, {getRecycleCoin: getRecycleCoin});
  server.bind('0.0.0.0:4500', grpc.ServerCredentials.createInsecure());
  server.start();
}

main();
