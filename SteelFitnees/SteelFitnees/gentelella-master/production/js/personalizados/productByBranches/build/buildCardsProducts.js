function buildProductById(json) {
    console.log(json)
    document.getElementById("containerCardsProducts").innerHTML = ""

    var ban = false;
    var htmlProducts = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            htmlProducts +=
                `              
                    <div class="col-xl-4 col-lg-4 col-md-4">
                        <div class="home-blog-single mb-30">
                            <div class="blog-img-cap">
                                <div class="blog-img">
                                    <img src="${json[i].imagen}" alt="" width="10" height="250">
                                    <!-- Blog date -->
                                    <div class="blog-date text-center">
                                        <span>$ ${json[i].precio}</span>
                                    </div>
                                </div>
                                <div class="blog-cap">
                                    <h4><a >${json[i].producto}</a></h3>
                                    <span>${json[i].Descripcion}</span>
                                </div>
                            </div>
                        </div>
                    </div>`
            if (i == 2) {
                break;
            }
        }
    }
    if (ban) {
        document.getElementById("containerCardsProducts").innerHTML = htmlProducts

    } else {
        document.getElementById("containerCardsProducts").innerHTML = `<h2 style="text-align:center">Sin productos por el momento</h2>`
    }
}