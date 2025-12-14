package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import javax.inject.Inject

class LogoutUseCase @Inject constructor(
    private val repository: UserRepository
) {
    suspend operator fun invoke() {
        repository.clear()
    }
}
