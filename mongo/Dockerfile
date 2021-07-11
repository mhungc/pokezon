FROM mongo
WORKDIR /
COPY "mongo/init.json" "init.json"
CMD mongoimport --host product.db --db ProductsStoreDb --collection Products --type json --file init.json --jsonArray