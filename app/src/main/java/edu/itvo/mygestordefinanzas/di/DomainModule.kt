package edu.itvo.mygestordefinanzas.di

import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import edu.itvo.mygestordefinanzas.domain.usecase.*
import javax.inject.Singleton

@Module
@InstallIn(SingletonComponent::class)
object DomainModule {

    @Provides
    @Singleton
    fun provideAddTransactionUseCase(
        repository: TransactionRepository
    ): AddTransactionUseCase {
        return AddTransactionUseCase(repository)
    }

    @Provides
    @Singleton
    fun provideDeleteTransactionUseCase(
        repository: TransactionRepository
    ): DeleteTransactionUseCase {
        return DeleteTransactionUseCase(repository)
    }

    @Provides
    @Singleton
    fun provideGetTransactionsUseCase(
        repository: TransactionRepository
    ): GetTransactionsUseCase {
        return GetTransactionsUseCase(repository)
    }


}