module MegaFacts

open canopy
open runner

// PageModel

let factsUrl = "http://localhost:3000"

// Enlaces a los diferentes héroes
let heroArturo = "#heroes li:nth-of-type(1) a"
let heroBruce = "#heroes li:nth-of-type(2) a"
let heroChuck = "#heroes li:nth-of-type(3) a"

// Información sobre el héroe selecciando
let currentHeroName = "#right-column h2"
let currentFacts = "#facts li"

// Controles para añadir facts
let newFactText = "#new-fact"
let addNewFact = "#add-new-fact"


// Definimos nuestros tests

let browseFacts _ =

    context "Consultando los facts de cada héroe"

    url factsUrl

    displayed "#heroes"

    "Al seleccionar un héroe se muestran sus facts" &&& fun _ ->
        
        click heroChuck

        currentHeroName == "Chuck Norris"

        currentFacts *= "Chuck Norris borró la papelera de reciclaje."

        click heroArturo

        currentHeroName == "Arturo Pérez-Reverte"

        currentFacts *= "Pérez-Reverte se baja música en casa de Ramoncín."

let addFact _ =
    
    context "Añadiendo un nuevo fact"

    "Al añadir un nuevo fact se muestra en la lista de facts" &&& fun _ ->

        click heroChuck

        currentHeroName == "Chuck Norris"

        newFactText << "Object hereda de Chuck Norris"

        click addNewFact

        currentFacts *= "Object hereda de Chuck Norris"


let all _ =
    browseFacts()        
    addFact()