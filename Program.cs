import networkx as nx
import matplotlib.pyplot as plt

# 1. Crear el grafo vacío
G = nx.Graph()

# 2. Añadir nodos (cafeterías y tipos de café)
cafeterias = ["C1", "C2", "C3", "C4"]
tipos_cafe = ["Arábica", "Robusta", "Geisha", "Typica"]
G.add_nodes_from(cafeterias)
G.add_nodes_from(tipos_cafe)

# 3. Añadir aristas (relaciones: la cafetería ofrece este tipo de café)
G.add_edge("C1", "Arábica")
G.add_edge("C1", "Geisha")
G.add_edge("C2", "Arábica")
G.add_edge("C2", "Robusta")
G.add_edge("C3", "Arábica")
G.add_edge("C3", "Typica")
G.add_edge("C4", "Geisha")
G.add_edge("C4", "Typica")

# 4. Calcular las métricas de centralidad
degree_centrality = nx.degree_centrality(G)
closeness_centrality = nx.closeness_centrality(G)
betweenness_centrality = nx.betweenness_centrality(G)
eigenvector_centrality = nx.eigenvector_centrality(G)

# 5. Imprimir los resultados
print("Centralidad de Grado:")
for nodo, centralidad in degree_centrality.items():
    print(f"{nodo}: {centralidad:.2f}")

print("\nCentralidad de Cercanía:")
for nodo, centralidad in closeness_centrality.items():
    print(f"{nodo}: {centralidad:.2f}")

print("\nCentralidad de Intermediación:")
for nodo, centralidad in betweenness_centrality.items():
    print(f"{nodo}: {centralidad:.2f}")

print("\nCentralidad de Vector Propio:")
for nodo, centralidad in eigenvector_centrality.items():
    print(f"{nodo}: {centralidad:.2f}")

# 6. (Opcional) Visualizar la red con los nodos coloreados por una métrica
pos = nx.spring_layout(G)  # Define la disposición de los nodos

# Ejemplo: Colorear por centralidad de grado
node_colors = [degree_centrality[node] * 500 for node in G.nodes()] # Escalar para mejor visualización

nx.draw(G, pos, with_labels=True, node_color=node_colors, cmap=plt.cm.Blues, node_size=2000)
sm = plt.cm.ScalarMappable(cmap=plt.cm.Blues, norm=plt.Normalize(vmin=min(node_colors), vmax=max(node_colors)))
sm.set_array([])
plt.colorbar(sm, label="Centralidad de Grado")
plt.title("Red de Cafeterías y Tipos de Café (Coloreado por Centralidad de Grado)")
plt.show()