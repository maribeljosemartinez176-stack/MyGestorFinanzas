package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import javax.inject.Inject

class GetUserUseCase @Inject constructor(
    private val repository: UserRepository
) {
    operator fun invoke() = repository.getUserPreferences()
}
