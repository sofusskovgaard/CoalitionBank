# CoalitionBank
A hypothetical bank built on microservices.

## Getting started
Here are a few steps to get started with the project.

### CosmosDB Emulator - MacOS

If you're on a mac you have to start up a container using the commands below. [More on this.](https://docs.microsoft.com/en-us/azure/cosmos-db/linux-emulator?tabs=ssl-netstd21#run-on-macos)

```bash
ipaddr="`ifconfig | grep "inet " | grep -Fv 127.0.0.1 | awk '{print $2}' | head -n 1`"
```

```bash
docker run -p 8081:8081 -p 10251:10251 -p 10252:10252 -p 10253:10253 -p 10254:10254  -m 3g --cpus=2.0 --name=cosmos-emulator -e AZURE_COSMOS_EMULATOR_PARTITION_COUNT=10 -e AZURE_COSMOS_EMULATOR_ENABLE_DATA_PERSISTENCE=true -e AZURE_COSMOS_EMULATOR_IP_ADDRESS_OVERRIDE=$ipaddr -d mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator
```