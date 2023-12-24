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
function main() {
let client = new service_proto.grpcService('localhost:4500',
                                       grpc.credentials.createInsecure());
 client.getRecycleCoin({carbonValue:25}, function(err, response) {
    console.log('Recycle coin value:' ,+response.recycleCoinValue);
  });
}
main();
