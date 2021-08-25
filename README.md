# Rabbit LAB
## Pacote
```
dotnet add package RabbitMQ.Client
```

## Rabbit no Docker local
```
docker run -p 15672:15672 -p 5672:5672 -d --name rabbitlab --hostname rabbitmqhost -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=pass -e RABBITMQ_DEFAULT_VHOST=my_vhost rabbitmq:3-management
```

## Rabbit acesso web
[http://localhost:15672](http://localhost:15672)</br>
***usuario:*** user</br>
***senha:*** pass</br>

## Conection string no .net
```
"ConnectionString": "amqp://user:pass@localhost:5672/my_vhost"
```

## Documentação docker
[Official](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)


## Iniciando o container Rabbit 
```
docker start rabbitlab
```
