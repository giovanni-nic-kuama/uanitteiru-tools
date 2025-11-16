## Build Docker image

docker build --no-cache --progress=plain -t uanittiru-tools:0.0.0 -f UanitteiruTools\Dockerfile .

## Export image as tarball

docker save -o uanittiru-tools.tar uanittiru-tools:0.0.0

## Load image to docker deamon

docker load -i uanittiru-tools.tar