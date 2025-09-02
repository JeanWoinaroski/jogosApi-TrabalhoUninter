package com.example.JogosAPI.model;

import jakarta.persistence.*;

@Entity
@Table(name = "jogos") // antes era "produtos"
public class Jogo {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) // se quiser ID auto-increment
    @Column(name = "id")
    private Long id;

    @Column(name = "nome", nullable = false)
    private String nome;

    @Column(name = "genero")
    private String genero;

    @Column(name = "ano")
    private Integer ano;

    @Column(name = "status")
    private String status; // "zerado" ou "não zerado"

    // Getters e setters
    public Long getId() {
        return id;
    }
    public void setId(Long id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getGenero() {
        return genero;
    }
    public void setGenero(String genero) {
        this.genero = genero;
    }

    public Integer getAno() {
        return ano;
    }
    public void setAno(Integer ano) {
        this.ano = ano;
    }

    public String getStatus() {
        return status;
    }
    public void setStatus(String status) {
        this.status = status;
    }

    @Override
    public String toString() {
        return "Jogo{" +
                "id=" + id +
                ", nome='" + nome + '\'' +
                ", genero='" + genero + '\'' +
                ", ano=" + ano +
                ", status='" + status + '\'' +
                '}';
    }
}
