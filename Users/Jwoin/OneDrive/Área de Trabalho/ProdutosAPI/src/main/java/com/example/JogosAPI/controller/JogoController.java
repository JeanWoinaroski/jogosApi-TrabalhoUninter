package com.example.JogosAPI.controller;

import com.example.JogosAPI.model.Jogo;
import com.example.JogosAPI.repository.JogoRepository;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/jogos")
public class JogoController {

    private final JogoRepository jogoRepository;

    public JogoController(JogoRepository jogoRepository) {
        this.jogoRepository = jogoRepository;
    }

    // GET - Lista todos os jogos
    @GetMapping
    public List<Jogo> listarTodos() {
        return jogoRepository.findAll();
    }

    // GET - Busca jogo por ID
    @GetMapping("/{id}")
    public ResponseEntity<Jogo> obterPorId(@PathVariable Long id) {
        Optional<Jogo> jogo = jogoRepository.findById(id);
        return jogo.map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // POST - Adiciona novo jogo
    @PostMapping
    public ResponseEntity<?> salvar(@RequestBody Jogo jogo) {
        // Validação simples
        if (jogo.getNome() == null || jogo.getNome().isEmpty()) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST)
                    .body("O campo 'nome' é obrigatório.");
        }
        if (jogo.getStatus() != null &&
                !jogo.getStatus().equalsIgnoreCase("zerado") &&
                !jogo.getStatus().equalsIgnoreCase("não zerado")) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST)
                    .body("O campo 'status' deve ser 'zerado' ou 'não zerado'.");
        }

        Jogo salvo = jogoRepository.save(jogo);
        return ResponseEntity.status(HttpStatus.CREATED).body(salvo);
    }

    // PUT - Atualiza jogo existente
    @PutMapping("/{id}")
    public ResponseEntity<?> atualizar(@PathVariable Long id, @RequestBody Jogo jogoAtualizado) {
        Optional<Jogo> jogoExistente = jogoRepository.findById(id);

        if (jogoExistente.isEmpty()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Jogo não encontrado.");
        }

        Jogo jogo = jogoExistente.get();
        jogo.setNome(jogoAtualizado.getNome());
        jogo.setGenero(jogoAtualizado.getGenero());
        jogo.setAno(jogoAtualizado.getAno());
        jogo.setStatus(jogoAtualizado.getStatus());

        Jogo atualizado = jogoRepository.save(jogo);
        return ResponseEntity.ok(atualizado);
    }

    // DELETE - Remove jogo
    @DeleteMapping("/{id}")
    public ResponseEntity<String> deletar(@PathVariable Long id) {
        if (jogoRepository.existsById(id)) {
            jogoRepository.deleteById(id);
            return ResponseEntity.ok("Jogo removido com sucesso.");
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Jogo não encontrado.");
        }
    }
}
