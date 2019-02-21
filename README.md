# MediatorSimples
Técnico  
Guid       Id  
String     Nome  
[]Jogador  Time  
  
AquecerJogador(id jogador)  
SubstituiJogador(Jogador Entra, Jogador Sai)

 ----

Jogador  
Guid   Id  
String Nome  
bool   EhTitular  
bool   EstaAquecendo  
bool   EstaEmCampo  
EntraEmCampo()  
SaiDeCampo()
  
  ----

QuartoArbitro  
Guid   Id  
String Nome  

LevantaPlaca()

---- 

O evento SubstituiJogadorHandler() dispara os eventos:  
JogadorSaiDeCampoHandler()  
EntraEmCampoHandler()  
LevantaPlacaHandler()
